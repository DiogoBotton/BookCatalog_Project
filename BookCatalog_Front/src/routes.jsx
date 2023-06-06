import React from 'react'
import { Routes, Route } from 'react-router-dom'

// Pages
import Home from './pages/Home'
import NotFound from './pages/NotFound'
import Catalog from './pages/Catalog'
import BookDetails from './pages/BookDetails'

export default function MainRoutes(){
    
    return(
        <Routes>
            <Route path="/" element={<Home/>} />
            <Route path="/catalog" element={<Catalog/>} />
            <Route path="/book/:id" element={<BookDetails/>} />

            {/* Caso página não encontrada */}
            <Route path="*" element={<NotFound/>} />
        </Routes>
    )
}