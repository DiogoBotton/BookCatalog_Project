import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import api from '../services/api'
import Header from '../components/Header/Header'
import Footer from '../components/Footer/Footer'
import { Divider, Grid, Typography } from '@mui/material'

function BookDetails() {
    const [book, setBook] = useState({})
    const [author, setAuthor] = useState('')
    const [category, setCategory] = useState('')
    const params = useParams()
    useEffect(() => {
        api.get('books/' + params.id)
            .then((data) => {
                setBook(data.data)
                setAuthor(data.data.author.name)
                setAuthor(data.data.categoryBook.description)
            })
    }, [])
    return (
        <div>
            <Header />
            <Grid container direction='row' justifyContent='space-evenly' sx={{ width: '80%', margin: 'auto' }} pt={5}>
                <Grid item>
                    <img src={'data:image/jpg;base64,' + book.imageBase64} style={{ maxWidth: '50vh', height: 'auto' }} />
                </Grid>
                <Grid item maxWidth="100vh">
                    <Divider />
                    <Grid container direction="column" wrap='nowrap' p={5}>
                        <Grid>
                            <Typography variant='h4' color="#ccc">
                                {book.name} - Volume: {book.volume}
                            </Typography>
                            <Typography variant='body2' color="#ccc">
                                {category}
                            </Typography>
                            <Typography variant='h6' color="#ccc">
                                {author}
                            </Typography>
                        </Grid>

                        <Grid pt={5}>
                            <Typography variant='h4' color="#ccc" pb={1}>
                                Sinopse
                                <Divider />
                            </Typography>
                            <Typography variant='body2' fontSize={18} color="#ccc">
                                {book.synopsis}
                            </Typography>
                        </Grid>
                    </Grid>
                    <Divider />
                </Grid>
            </Grid>
            <Footer />
        </div>
    )
}

export default BookDetails
