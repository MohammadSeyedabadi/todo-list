import React from 'react'
import Row from 'react-bootstrap/Row'
import { Link } from 'react-router-dom'

export default function Footer() {
  return (
    <footer className="footer">
      <section>
        <Row className="text-center mb-3">
          <h2 className="fw-semibold fs-6">Thanks for reading!</h2>
          <p className="fw-semibold">© Mohammad Seyedabadi, 2023-Present</p>
        </Row>
        <Row>
          <nav className="d-flex justify-content-evenly footer--nav">
            <a
              style={{ pointerEvents: 'none' }}
              href="#"
              className="fw-semibold fs-6 link--title text-secondary"
            >
              Twitter
            </a>
            <a
              href="https://github.com/MohammadSeyedabadi"
              className="fw-semibold fs-6 link--title"
            >
              GitHub
            </a>
            <a
              href="https://www.linkedin.com/in/mohammad-seyedabadi-397a61256/"
              className="fw-semibold fs-6 link--title"
            >
              LinkedIn
            </a>
            <a
              style={{ pointerEvents: 'none' }}
              href="#"
              className="fw-semibold fs-6 link--title text-secondary"
            >
              Dribbble
            </a>
          </nav>
        </Row>
      </section>
    </footer>
  )
}
