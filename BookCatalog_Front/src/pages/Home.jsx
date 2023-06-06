import React, { useEffect, useState } from 'react';
import Header from '../components/Header/Header';
import { Card, CardContent, CardMedia, Typography, CardActionArea, Grid, Container, Paper } from '@mui/material';
import { Box } from '@mui/material';
import { Swiper, SwiperSlide } from 'swiper/react';
import { Navigation, Autoplay, EffectCoverflow, Zoom } from 'swiper';
import 'swiper/css'
import styles from '../styles/home.module.css'
import Footer from '../components/Footer/Footer';
import api from '../services/api'
import { useNavigate } from 'react-router-dom';

function Home() {
    const [books, setBooks] = useState([])
    const navigate = useNavigate()

    useEffect(() => {
        api.get('Books/lastReleases/10')
        .then((data) => {
            setBooks(data.data)
        })
    }, [])

    return (
        <div>
            <Header />
            <Box className={styles.bgHome} pt={40} pb={40} >
                <Typography textAlign="center" variant="h4" color="#ccc">
                    A Livraria dos seus sonhos!
                </Typography>
            </Box>

            <Typography textAlign='center' variant="h4" pt={5} pb={5} color="#fff">
                Ultimos Lançamentos
            </Typography>
            <Paper>
                <Box sx={{ width: '80%', margin: 'auto' }} p={1}>
                    <Swiper
                        modules={[Navigation, Autoplay, EffectCoverflow, Zoom]}
                        slidesPerView={5}
                        grabCursor
                        navigation
                        autoplay={{ delay: 5000 }}
                        zoom
                        className="swiper-container"
                    >
                        {
                            books.map((book) => (
                                <SwiperSlide key={book.id} className="slide-item" onClick={() => navigate(`/book/${book.id}`)}>
                                    <Grid>
                                        <Card sx={{ maxWidth: 220, backgroundColor: '#222222' }}>
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="auto"
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
                                </SwiperSlide>
                            ))
                        }
                    </Swiper>
                </Box>
            </Paper>

            <Footer />
        </div>
    )
}

export default Home
