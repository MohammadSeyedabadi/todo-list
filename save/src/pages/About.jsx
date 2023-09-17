import React from 'react'
import { Link } from 'react-router-dom'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Image from 'react-bootstrap/Image'
import Me from '../images/tania.JPG'
import Resume from '../resume/Resume.pdf'

export default function MainPage() {
  return (
    <main className="mt-5">
      <article className="hero-description fs-5">
        <Row>
          <Col md={9} className="pe-5">
            <h1 className="heading pt-md-5">About</h1>
            <p className="mb-5">
              I'm Mohammad! I'm a software developer working in Neyshabur.
              Welcome to my spot on the web for my projects, tutorials and
              anything else I want to show the world. Check out the{' '}
              <Link to="/Projects" className="article--p-a">
                projects
              </Link>{' '}
              page to see all of my open-source work, and the{' '}
              <Link to="/Blog" className="article--p-a">
                blog
              </Link>{' '}
              for my tutorials and more.
            </p>
            <h2 id="work-experience">
              <a href="#work-experience" className="link--title">
                Work Experience
              </a>
            </h2>
            <p>
              I won't bore you too much with my work history, though; that's
              what my{' '}
              <a href={Resume} download className="article--p-a">
                CV
              </a>
              ,{' '}
              <a
                href="https://github.com/MohammadSeyedabadi"
                className="article--p-a"
              >
                Github
              </a>{' '}
              and{' '}
              <a
                href="https://www.linkedin.com/in/mohammad-seyedabadi-397a61256/"
                className="article--p-a"
              >
                LinkedIn
              </a>{' '}
              are for.
            </p>
          </Col>
          <Col md={3}>
            <aside className="pt-md-5">
              <div className="p-3 aside--card">
                <h2 className="fs-6 fw-bold pb-3 mb-0">ME</h2>
                <Image src={Me} fluid alt="Mohammad" className="picture" />
              </div>
            </aside>
          </Col>
        </Row>
      </article>
    </main>
  )
}
