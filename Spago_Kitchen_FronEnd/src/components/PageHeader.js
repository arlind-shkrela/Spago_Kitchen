import { Card, makeStyles, Paper, Typography } from "@material-ui/core";
import React from "react";

const useStyles = makeStyles({
  root: {
    backgroundColor: "#fdfdff",
  },
  pageHeader: {
    padding: "4rem",
    display: "flex",
    marginBottom: "3rem",
  },
  pageIcon: {
    display: "inline-block",
    padding: "2rem",
    color: "#3c44b1",
  },
  pageTitle: {
    display: "inline-block",
    paddingLeft: "4rem",
  },
});

export default function PageHeader(props) {
  const classes = useStyles();
  const { icon, title, subtitle } = props;
  return (
    <Paper elevation={0} square>
      <div className={classes.pageHeader}>
        <Card className={classes.pageIcon}>{icon}</Card>
        <div className={classes.pageTitle}>
          <Typography variant="h3" component="div">
            {title}
          </Typography>
          <Typography variant="h6" component="div">
            {subtitle}
          </Typography>
        </div>
      </div>
    </Paper>
  );
}
