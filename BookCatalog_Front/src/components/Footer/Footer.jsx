import { Box, Container, Paper, Typography, Grid, IconButton, Divider, Link } from '@mui/material'
import {
    Facebook as FacebookIcon, Instagram as InstagramIcon, Twitter as TwitterIcon, YouTube as YoutubeIcon,
    LinkedIn as LinkedinIcon, AutoStories as AutoStoriesIcon
} from '@mui/icons-material';
import React, { useEffect, useState } from 'react'

function Footer() {
    const [isMobile, setIsMobile] = useState(window.innerWidth <= 992);

    useEffect(() => {
        window.addEventListener('resize', () => {
            setIsMobile(window.innerWidth <= 992);
        }, false);
    }, []);
    return (
        <footer>
            <Paper sx={{ bgcolor: '#161616', marginTop: 10 }}>
                <Divider />
                <Box
                    px={{ xs: 3, sm: 10 }}
                    py={{ xs: 5, sm: 10 }}>
                    <Container maxWidth={false}>
                        <Grid container spacing={5} wrap={isMobile ? 'wrap' : 'nowrap'} textAlign="center" direction={isMobile ? 'column' : 'row'} justifyContent='center'>

                            <Grid container item xs={4} sm={4} justifyContent='center' >
                                <Grid container display="flex" direction="row" >
                                    <AutoStoriesIcon sx={{ display: { xs: 'flex', md: 'flex' }, mr: 1 }} />
                                    <Typography
                                        variant="h6"
                                        noWrap
                                        component="a"
                                        href="/"
                                        sx={{
                                            mr: 2,
                                            display: { xs: 'flex', md: 'flex' },
                                            fontFamily: 'monospace',
                                            fontWeight: 700,
                                            letterSpacing: '.3rem',
                                            color: 'inherit',
                                            textDecoration: 'none',
                                        }}
                                    >
                                        Livraria
                                    </Typography>
                                </Grid>
                                <Grid container>
                                    <Typography sx={{fontFamily: 'monospace'}}>
                                        A Livraria dos seus sonhos.
                                    </Typography>
                                </Grid>
                            </Grid>

                            <Divider orientation='vertical' flexItem sx={{ display: { xs: 'none', md: 'inline' } }} />

                            <Grid item xs={4} sm={4} sx={{ display: { xs: 'none', md: 'inline' } }}>
                                <Box pb={2}>
                                    <Typography textAlign='center' variant="h5" component="h5" noWrap>
                                        Siga-nos nas redes sociais
                                    </Typography>
                                </Box>
                                <Box display="flex" direction="row" pb={2} justifyContent="center">
                                    <Grid pr={1}>
                                        <IconButton size='small'>
                                            <FacebookIcon fontSize='large' />
                                        </IconButton>
                                    </Grid>
                                    <Grid pr={1}>
                                        <IconButton size='small'>
                                            <InstagramIcon fontSize='large' />
                                        </IconButton>
                                    </Grid>
                                    <Grid pr={1}>
                                        <IconButton size='small'>
                                            <TwitterIcon fontSize='large' />
                                        </IconButton>
                                    </Grid>
                                    <Grid pr={1}>
                                        <IconButton size='small'>
                                            <YoutubeIcon fontSize='large' />
                                        </IconButton>
                                    </Grid>
                                    <Grid pr={1}>
                                        <IconButton size='small'>
                                            <LinkedinIcon fontSize='large' />
                                        </IconButton>
                                    </Grid>
                                </Box>
                            </Grid>

                            <Divider orientation='vertical' flexItem sx={{ display: { xs: 'none', md: 'inline' } }} />

                            <Grid container item xs={4} sm={4} direction="column">
                                <Link href="#" color='inherit' component="button" variant="body2" fontSize={16} underline='hover'>
                                    Quem Somos
                                </Link>
                                <Link href="#" color='inherit' component="button" variant="body2" fontSize={16} underline='hover'>
                                    Trabalhe Conosco
                                </Link>
                                <Link href="#" color='inherit' component="button" variant="body2" fontSize={16} underline='hover'>
                                    Publique Conosco
                                </Link>
                                <Link href="#" color='inherit' component="button" variant="body2" fontSize={16} underline='hover'>
                                    Fale Conosco
                                </Link>
                            </Grid>
                        </Grid>

                    </Container>
                </Box>
            </Paper>
        </footer>
    )
}

export default Footer
