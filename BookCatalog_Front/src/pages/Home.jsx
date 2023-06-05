import React from 'react';
import Header from '../components/Header/Header';
import { Card, CardContent, CardMedia, Typography, CardActionArea, Grid, Container, Paper } from '@mui/material';
import { Box } from '@mui/material';
import { Swiper, SwiperSlide } from 'swiper/react';
import { Navigation, Autoplay, EffectCoverflow, Zoom } from 'swiper';
import 'swiper/css'
import styles from '../styles/home.module.css'

function Home() {
    const books = ["Senhor dos aneis", "Hobbit", "Terra", "Hobbit", "Hobbit", "Hobbit", "Hobbit", "Hobbit"]
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
                                <SwiperSlide className="slide-item">
                                    <Grid>
                                        <Card sx={{ maxWidth: 250, backgroundColor: '#222222' }}>
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="250"
                                                    image="https://avatars.githubusercontent.com/u/54954629?v=4"
                                                    alt="green iguana"
                                                />
                                                <CardContent>
                                                    <Typography textAlign='center' gutterBottom variant="h6" component="div">
                                                        {book}
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
        </div>
    )
}

export default Home
