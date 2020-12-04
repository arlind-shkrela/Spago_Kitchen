import React from "react";
import { NavLink } from "react-router-dom";

const Header = () => {
  const activeStyle = { color: "#F15B2A" };
  return (
    <nav>
      <NavLink to="/" activeStyle={activeStyle} exact>
        Home
      </NavLink>
      {" | "}
      <NavLink to="/about" activeStyle={activeStyle}>
        About
      </NavLink> 
      {" | "}
      <NavLink to="/dish" activeStyle={activeStyle}>
        Dishes
      </NavLink>
      {" | "}
      <NavLink to="/categories" activeStyle={activeStyle}>
        Categories
      </NavLink>
      {" | "}
      <NavLink to="/cousine" activeStyle={activeStyle}>
        Cousine
      </NavLink>
      {" | "}
      <NavLink to="/ingredients" activeStyle={activeStyle}>
        Ingredients
      </NavLink>
    </nav>
  );
};

export default Header;
