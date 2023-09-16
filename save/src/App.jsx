import React, {useState, useEffect} from 'react'
import Container from 'react-bootstrap/Container'
import { Routes, Route } from 'react-router-dom'
import Navigation from './components/Navigation'
import Footer from './components/Footer'
import MainPage from './pages/MainPage'
import About from './pages/About'
import Projects from './pages/Projects'
import Contact from './pages/Contact'
import Blog from './pages/Blog'
import { keepTheme } from './utils/themes';

export default function App() {
  const [className, setClassName] = useState("theme-dark");
  useEffect(() => {
    keepTheme(setClassName)
  }, [setClassName])
  return (
    <div className={className}>
      <Container className='App'>
        <Navigation setClassName={setClassName} />
        <Routes>
          <Route
            path="/my-website"
            element={<MainPage />}
          />
          <Route path="/about" element={<About />} />
          <Route path="/blog" element={<Blog />} />
          <Route path="/contact" element={<Contact />} />
          <Route path="/projects" element={<Projects />} />
        </Routes>
        <Footer />
      </Container>
    </div>
  )
}