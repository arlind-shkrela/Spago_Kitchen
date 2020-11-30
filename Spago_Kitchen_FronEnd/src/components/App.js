import React from "react";
import { Route, Switch } from "react-router-dom";
import HomePage from "./home/HomePage";
import AboutPage from "./about/AboutPage";
import CategoryPage from "./categories/CategoryPage";
import CousinePage from "./cousine/CousinePage";
import DishPage from "./dish/DishPage";
import IngredientsPage from "./ingredients/IngredientsPage";
import Header from "./common/Header";
import PageNotFound from "./PageNotFound";

function App() {
  return (
    <div className="container-fluid">
      <Header />
      <Switch>
        <Route exact path="/" component={HomePage} />
        <Route path="/about" component={AboutPage} />
        <Route path="/dish" component={DishPage} />
        <Route path="/categories" component={CategoryPage} />
        <Route path="/cousine" component={CousinePage} />
        <Route path="/ingredients" component={IngredientsPage} />
        <Route component={PageNotFound} />
      </Switch>
    </div>
  );
}

export default App;
