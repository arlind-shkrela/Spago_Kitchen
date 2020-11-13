import React from "react";
import { Route, Switch } from "react-router-dom";
import HomePage from "./home/HomePage";
import AboutPage from "./about/AboutPage";
import CategoryPage from "./categories/CategoryPage";
import CousinePage from "./cousine/CousinePage";
import Header from "./common/Header";
import PageNotFound from "./PageNotFound";
import CoursesPage from "./courses/CoursesPage";

function App() {
  return (
    <div className="container-fluid">
      <Header />
      <Switch>
        <Route exact path="/" component={HomePage} />
        <Route path="/about" component={AboutPage} />
        <Route path="/categories" component={CategoryPage} />
        <Route path="/cousine" component={CousinePage} />
        <Route path="/courses" component={CoursesPage} />
        <Route component={PageNotFound} />
      </Switch>
    </div>
  );
}

export default App;
