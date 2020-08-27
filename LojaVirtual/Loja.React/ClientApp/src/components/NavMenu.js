import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">Home</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                <ul className="navbar-nav center">
                    <NavItem>
                        <NavLink tag={Link} className="text-dark" to="/About">A Marca</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink tag={Link} className="text-dark" to="/Feminino">Feminino</NavLink>
                    </NavItem>
                    <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/Masculino">Masculino</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink tag={Link} className="text-dark" to="/off-price">Off Price</NavLink>
                    </NavItem>
                </ul>
             </Collapse>
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/Cart"><i class="fas fa-shopping-cart"></i></NavLink>
                </NavItem>
                <NavItem> 
                  <NavLink tag={Link} className="text-dark" to="/Register">Registrar</NavLink>  
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/Login">Entrar</NavLink>  
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
