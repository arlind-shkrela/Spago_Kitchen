import { Card, makeStyles, Paper, Typography } from "@material-ui/core";
import React from "react";
import FormDialog from "../shared/modal";
import Button from "@material-ui/core/Button";

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
  let [openDialog, setOpen] = React.useState();

  const handleClickOpen = () => {
    setOpen = true;
  };
  const handleClose = () => {
    setOpen(false);
  };
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
        <Button variant="outlined" color="primary" onClick={handleClickOpen}>
          <FormDialog
            open={openDialog}
            setOpen={openDialog}
            dialogName="Set new Dish"
            DialogDiscription="Go ahead and insert new!"
            label="Add New"
            className={{ backgroundColor: "#000" }}
            
          />
        </Button>
      </div>
    </Paper>
  );
}
