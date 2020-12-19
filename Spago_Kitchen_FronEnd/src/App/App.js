import { CssBaseline, makeStyles } from "@material-ui/core";
import "./App.css";
import SideMenu from "../components/SideMenu";
import Header from "../components/Header";
import PageHeader from "../components/PageHeader";
import GroupIcon from "@material-ui/icons/Group";

const useStyles = makeStyles({
  appMain: {
    paddingLeft: "320px",
    width: "100%",
  },
});

function App() {
  const classes = useStyles();
  return (
    <>
      <SideMenu />
      <div className={classes.appMain}>
        <Header></Header>
        <PageHeader
          title="Page Header"
          subtitle="pageDisc"
          icon={<GroupIcon fontSize="large" />}
        ></PageHeader>
      </div>
      <CssBaseline />
    </>
  );
}

export default App;
