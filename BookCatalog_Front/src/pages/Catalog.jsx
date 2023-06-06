import React, { useEffect, useState } from 'react'
import Header from '../components/Header/Header'
import { Card, CardActionArea, CardContent, CardMedia, Grid, Paper, Typography, TextField } from '@mui/material'
import Footer from '../components/Footer/Footer'
import api from '../services/api'
import { useNavigate } from 'react-router-dom'

function Catalog() {
    const [filter, setFilter] = useState('')
    const [booksDb, setBooksDb] = useState([])
    const [books, setBooks] = useState([])
    const navigate = useNavigate()

    useEffect(() => {
        api.get('Books/all')
        .then((data) => {
            setBooks(data.data)
            setBooksDb(data.data)
        })
    }, [])

    useEffect(() => {
        if (booksDb.length > 0) {
            let booksFiltered = booksDb.filter((book) => {
                if (filter.length === 0)
                    return booksDb
                
                // Normalize e replace => Retira acentuações
                return book.name.toLowerCase().normalize('NFD').replace(/[\u0300-\u036f]/g, "").includes(filter.toLowerCase().normalize('NFD').replace(/[\u0300-\u036f]/g, ""))
            })

            setBooks(booksFiltered)
        }
    }, [filter])

    return (
        <div>
            <Header />
            <Typography textAlign='center' variant="h4" pt={5} pb={5} color="#fff">
                Catálogo de Livros
            </Typography>
            <Grid container direction='column' sx={{ width: '80%', margin: 'auto' }}>
                <Grid sx={{ width: '50%', margin: 'auto' }} pb={5}>
                    <Paper>
                        <TextField variant='outlined' placeholder='Pesquisar Livro' fullWidth onKeyUp={(e) => { setFilter(e.target.value) }} />
                    </Paper>
                </Grid>

                <Grid item>
                    <Paper>
                        <Grid container justifyContent='center' direction='row' sx={{ maxHeight: '50em', overflow: 'auto' }}>
                            {
                                books.map((book) => (
                                    <Grid item key={book.id} p={1} onClick={() => navigate(`/book/${book.id}`)}>
                                        <Card sx={{ maxWidth: 250, backgroundColor: '#222222' }}>
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="250"
                                                    image={'data:image/jpg;base64,' + book.imageBase64}
                                                    alt={book.name}
                                                />
                                                <CardContent>
                                                    <Typography textAlign='center' gutterBottom variant="body2" component="div">
                                                        {book.name}
                                                    </Typography>
                                                </CardContent>
                                            </CardActionArea>
                                        </Card>
                                    </Grid>
                                ))
                            }
                            {
                                books.length === 0 && <Typography textAlign='center' variant="h6" pt={5} pb={5} color="#fff">
                                    Nenhum livro com este nome
                                </Typography>
                            }
                        </Grid>
                    </Paper>
                </Grid>
            </Grid>

            <Footer />
        </div>
    )
}

export default Catalog
