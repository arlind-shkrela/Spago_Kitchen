import React from "react";
import { Link } from "react-router-dom";

const HomePage = () => (
  <div className="jumbotron">
    <h1>Spago Kitchen.</h1>
    <i>Spago is referet after intalian dish sapgeti: Web app for browsering our dishes.</i>
    <Link to="about" className="btn btn-primary btn-lg">
      Learn more
    </Link>
  </div>
);

export default HomePage;
