import React, {useEffect, useState} from 'react';
import {Button, Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink} from 'reactstrap';
import { Link } from 'react-router-dom';
import { getToken, destroyToken } from "../../api/jwt.service";
import '../../assets/NavMenu.css';
import { useNavigate  } from 'react-router-dom'

const NavMenu = () => {
  const navigate = useNavigate();
  const [collapsed, setcollapsed] = useState(false);
  const [token, setToken] = useState(null);
  
  const toggleNavbar = () => {
    setcollapsed(!collapsed);
  }
  
  const logout = () => {
    destroyToken();
    setToken(null)
    navigate('/login');
    window.location.reload();
  }
  
  useEffect(() => {
    if (getToken()) {
      setToken(getToken());
    }
  },[token])

  return (
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
        <NavbarBrand tag={Link} to="/">TaskFlow</NavbarBrand>
        <NavbarToggler onClick={toggleNavbar} className="mr-2" />
        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={collapsed} navbar>
          <ul className="navbar-nav flex-grow">
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
            </NavItem>
            {
              token ? (
                <>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/assignments">Mis tareas</NavLink>
                  </NavItem>
                  <Button onClick={logout}>
                    Cerrar Sesión
                  </Button>
                </>
              ) : (
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/login">Iniciar sesión</NavLink>
                </NavItem>
              )
            }
          </ul>
        </Collapse>
      </Navbar>
    </header>
  );
}

export default NavMenu;