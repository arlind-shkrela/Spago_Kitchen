import { makeStyles } from "@material-ui/core";
import React from "react";
import HomePage from "../components/mainPages/HomePage";
import AboutPage from "../components/mainPages/about";
import IndexCousine from "../components/cousine/index";
import DishIndex from "../components/dish/dishIndex";
import PageNotFound from "./PageNotFound";

import { Route, Switch, NavLink } from "react-router-dom";

const useStyles = makeStyles({
  sideMenu: {
    display: "flex",
    flexDirection: "column",
    position: "absolute",
    left: "0px",
    width: "320px",
    height: "100%",
    backgroundColor: "#253053",
  },
});

export default function SideMenu() {
  const classes = useStyles();
  const activeStyle = { color: "#F15B2A" };
  return (
    <div className={classes.sideMenu}>
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

      <Switch>
        <Route exact path="/" component={HomePage} />
        <Route path="/about" component={AboutPage} />
        <Route path="/dish" component={DishIndex} />
        <Route path="/cousine" component={IndexCousine} />
        <Route component={PageNotFound} />
      </Switch>
    </div>
  );
}
