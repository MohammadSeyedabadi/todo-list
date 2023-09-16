import React from 'react'
// import Image from 'react-bootstrap/Image'
import 'bootstrap-icons/font/bootstrap-icons.css'
import { Link, useMatch, useResolvedPath } from 'react-router-dom'
import Toggle from './Toggle'

export default function Navigation(props) {
  return (
    <header className="navigation" id="navigation">
      <nav className="nav--container d-flex align-items-center">
        {/* <Link to="/my-website" className="fw-semibold">
          <span className="me-2">
              <Image
                src="../images/logo.png"
                fluid
                alt="logo"
                className="nav--img"
              />
            </span>
          <span className="letter-spacing site--name fw-medium">
            Mohammad Seyedabadi
          </span>
        </Link> */}
        <span className="nav-tog">
          <Toggle setClassName={props.setClassName} />
        </span>

        <div className="nav--menu" id="nav-menu">
          <ul className="nav--list">
            <CustomLink to="/my-website" className="fw-semibold nav--link home">
              <span className="nav__name">Home</span>
            </CustomLink>

            <CustomLink to="/about" className="fw-semibold nav--link about">
              <span className="nav__name">About</span>
            </CustomLink>

            <CustomLink
              to="/Projects"
              className="fw-semibold nav--link projects"
            >
              <span className="nav__name">Projects</span>
            </CustomLink>

            <CustomLink to="/contact" className="fw-semibold nav--link contact">
              <span className="nav__name">Contact</span>
            </CustomLink>

            <CustomLink to="/Blog" className="fw-semibold nav--link blog">
              <span className="nav__name">Blog</span>
            </CustomLink>

            {/* <li className="nav__item mb-3">
              <Toggle setClassName={props.setClassName} />
            </li> */}
          </ul>
        </div>
      </nav>
      <hr className="my-0" />
    </header>
  )
}

function CustomLink({ to, children, ...props }) {
  const resolvedPath = useResolvedPath(to)
  const isActive = useMatch({ path: resolvedPath.pathname, end: true })

  return (
    <li className={isActive ? 'active--link' : ''}>
      <Link to={to} {...props}>
        {children}
      </Link>
    </li>
  )
}