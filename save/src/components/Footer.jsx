import React from 'react'
import Row from 'react-bootstrap/Row'
import { Link } from 'react-router-dom'

export default function Footer() {

  return (
    <footer className="footer">
      <section>
        <Row className="text-center mb-3">
          <h2
            className="fw-semibold fs-6"
          >
            Thanks for reading!
          </h2>
          <p
            className="fw-semibold"
          >
            © Mohammad Seyedabadi, 2023-Present
          </p>
        </Row>
        <Row>
          <nav className="d-flex justify-content-evenly footer--nav">
            <Link
              to="#"
              className="fw-semibold fs-6 link--title"
            >
              Twitter
            </Link>
            <Link
              to="#"
              className="fw-semibold fs-6 link--title"
            >
              GitHub
            </Link>
            <Link
              to="#"
              className="fw-semibold fs-6 link--title"
            >
              LinkedIn
            </Link>
            <Link
              to="#"
              className="fw-semibold fs-6 link--title"
            >
              Dribbble
            </Link>
          </nav>
        </Row>
      </section>
    </footer>
  )
}