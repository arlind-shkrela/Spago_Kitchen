import { CssBaseline, makeStyles } from "@material-ui/core";
import "./App.css";
import SideMenu from "../components/SideMenu";

import { Route, Switch } from "react-router-dom";
import HomePage from "../components/mainPages/HomePage";
import AboutPage from "../components/mainPages/about";
import IndexCousine from "../components/cousine/index";
import DishIndex from "../components/dish/dishIndex";
import PageNotFound from "../components/PageNotFound";

const useStyles = makeStyles({
  appMain: {
    paddingLeft: "73px",
    width: "100%",
    paddingTop: "2%",
  },
});

function App() {
  const classes = useStyles();
  return (
    <div className={classes.appMain}>
      <SideMenu />
      <CssBaseline />
      <Switch>
        <Route exact path="/" component={HomePage} />
        <Route exact path="/home" component={HomePage} />
        <Route path="/about" component={AboutPage} />
        <Route path="/dish" component={DishIndex} />
        <Route path="/dish" component={DishIndex} />
        <Route path="/dish" component={DishIndex} />

        <Route path="/cousine" component={IndexCousine} />
        <Route component={PageNotFound} />
      </Switch>
    </div>
  );
}

export default App;
