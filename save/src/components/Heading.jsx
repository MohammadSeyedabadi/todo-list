import React from 'react'
import { Link } from 'react-router-dom'

export default function Heading({ title, slug }) {
  return (
    <div className="d-flex justify-content-between">
      <div className="heading">
        <h2>{title}</h2>
      </div>
      {slug && (
        <div>
          <Link to={slug} className="btn--1">
            View all
          </Link>
        </div>
      )}
    </div>
  )
}
