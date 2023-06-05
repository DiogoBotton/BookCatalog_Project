import React from 'react';
import Header from '../components/Header/Header';
import { Card, CardContent, CardMedia, Typography, CardActionArea, Grid } from '@mui/material';

function Home() {
    const books = ["Senhor dos aneis", "Hobbit", "Terra", "Hobbit", "Hobbit", "Hobbit", "Hobbit", "Hobbit"]
    return (
        <div>
            <Header />
            <Typography textAlign='center' variant="h4" pt={5} pb={5}>
                Catálogo de Livros
            </Typography>
            <Grid container justifyContent="space-evenly" wrap='wrap' margin='auto' maxWidth="80em">
                {
                    books.map((book) => (
                        <Grid p={2}>
                            <Card sx={{ width: 250, bgcolor: '#383838' }}>
                                <CardActionArea>
                                    <CardMedia
                                        component="img"
                                        height="250"
                                        image="https://avatars.githubusercontent.com/u/54954629?v=4"
                                        alt="green iguana"
                                    />
                                    <CardContent>
                                        <Typography textAlign='center' gutterBottom variant="h6" component="div" color='#ccc'>
                                            {book}
                                        </Typography>
                                    </CardContent>
                                </CardActionArea>
                            </Card>
                        </Grid>
                    ))
                }
            </Grid>
        </div>
    )
}

export default Home
