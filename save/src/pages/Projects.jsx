import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import axios from 'axios'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import 'bootstrap-icons/font/bootstrap-icons.css'
import { projectsList } from '../data/projectsList'

const url = axios.create({
  baseURL: 'https://api.github.com/users/mohammadseyedabadi/repos?per_page=100',
})

export default function Card() {
  const [repos, setRepos] = useState([])
  const [reposError, setReposError] = useState(null)

  useEffect(() => {
    url
      .get('/')
      .then((res) => {
        setRepos(res.data)
      })
      .catch((error) => {
        setReposError(error)
      })
  }, [])

  const repo = repos?.map((repo) => {
    return (
      <Col key={repo.name} className="d-flex justify-content-center">
        <div className="project--wrapper" style={{ position: 'relative' }}>
          <div className="pb-4">
            <div className="d-flex justify-content-between align-items-center mb-1">
              <time className="project--time">
                {repo.created_at.split('-')[0]}
              </time>
              <div>
                <i className="star--icon bi bi-star me-1"></i>
                <Link
                  to={`https://github.com/MohammadSeyedabadi/${repo.name}/stargazers`}
                  className="star--count"
                >
                  {repo.stargazers_count}
                </Link>
              </div>
            </div>
            <Link to={repo.html_url} className="link--title fw-semibold fs-5">
              {repo.name}
            </Link>
            <p className="project--p mt-2 fw-semibold">{repo.description}</p>
          </div>
          <div style={{ position: 'absolute', bottom: '1.5rem' }}>
            <Link to={repo.html_url} className="btn--1 me-2">
              Source
            </Link>
            {projectsList.map((project) => {
              if (project.name == repo.name) {
                return (
                  <Link
                    key={project.demoUrl}
                    to={project.demoUrl}
                    className="btn--1 me-2"
                  >
                    Demo
                  </Link>
                )
              } else {
                return null
              }
            })}

            {projectsList.map((project) => {
              if (project.html_url == repo.html_url) {
                return (
                  <Link
                    key={project.articleUrl}
                    to={project.articleUrl}
                    className="btn--1"
                  >
                    Article
                  </Link>
                )
              } else {
                return null
              }
            })}

          </div>
        </div>
      </Col>
    )
  })

  //   if (repos) {
  //     console.log(repos[3])
  //     console.log(repos[3]?.name)
  //     console.log(repos[0].created_at.split("-")[0])
  //     console.log(repos[3]?.html_url)
  //     console.log(repos[3]?.stargazers_count)
  //   }

  return (
    <main className="mt-5">
      <h1 className="heading py-md-5">projects</h1>
      <Row xs={1} md={2} lg={3} className="gy-2 gy-md-3 gx-2 gx-md-3">
        {repo}
      </Row>
    </main>
  )
}
