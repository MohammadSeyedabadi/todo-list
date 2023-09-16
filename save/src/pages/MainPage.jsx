import React from 'react'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import { Link } from 'react-router-dom'

import Heading from '../components/Heading'
import { MainPageProjects } from "../data/MainPageProjects"

export default function MainPage() {
  return (
    <main className="mt-5">
      <article>
        <Row>
          <Col sm={7}>
            <h1 className="heading pt-md-5">Hey, I'm Mohammad!</h1>
            <p className="hero-description fs-5 fw-semibold">
              Welcome to my digital garden. 🌱
              <br />
              <br />
              I'm a software developer in Chicago. I make open-source projects
              and write about code, design, and life. I like accordions,
              drawing, sci-fi, reading, and gaming.
            </p>
          </Col>
        </Row>
        <Row className="mt-5 mb-3">
          <Col sm={12}>
            <Heading title="projects" slug="/projects" />
          </Col>
        </Row>
        <Row xs={1} md={2} lg={3} className="gy-2 gy-md-3 gx-2 gx-md-3">
          {MainPageProjects.map((project) => {
            return (
              <Col key={project.name} className="d-flex justify-content-center">
                <div
                  className="project--wrapper"
                  style={{ position: 'relative' }}
                >
                  <div className="pb-4">
                    <div className="d-flex justify-content-between align-items-center mb-1">
                      <time className="project--time">{project.time}</time>
                      {/* <div>
                        <i className="star--icon bi bi-star me-1"></i>
                        <Link
                          to={project.url}
                          className="star--count"
                        >
                          {repo.stargazers_count}
                        </Link>
                      </div> */}
                    </div>
                    <Link
                      to={project.url}
                      className="link--title fw-semibold fs-5"
                    >
                      {project.name}
                    </Link>
                    <p className="project--p mt-2 fw-semibold">
                      {project.description}
                    </p>
                  </div>
                  <div style={{ position: 'absolute', bottom: '1.5rem' }}>
                    {project.article && (
                      <Link to={project.article} className="btn--1 me-2">
                        Article
                      </Link>
                    )}

                    {project.url && (
                      <Link to={project.url} className="btn--1 me-2">
                        Source
                      </Link>
                    )}
                    {project.demoUrl && (
                      <Link to={project.demoUrl} className="btn--1">
                        Demo
                      </Link>
                    )}
                  </div>
                </div>
              </Col>
            )
          })}
        </Row>
      </article>
    </main>
  )
}
