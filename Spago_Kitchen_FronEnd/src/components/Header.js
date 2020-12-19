import {
  AppBar,
  Grid,
  InputBase,
  IconButton,
  Toolbar,
  Badge,
  makeStyles,
} from "@material-ui/core";
import React from "react";
import SettingsIcon from "@material-ui/icons/Settings";
import NotificationsIcon from "@material-ui/icons/Notifications";
import ChatBubbleIcon from "@material-ui/icons/ChatBubble";
import PowerSettingsNewIcon from "@material-ui/icons/PowerSettingsNew";
import SearchIcon from "@material-ui/icons/Search";

const useStyles = makeStyles({
  root: {
    backgroundColor: "#fff",
    transform: "translateZ(0)",
  },
  searchInput: {
    fontSize: "1.2rem",
    padding: "0px 8px",
  },
});

export default function Header() {
  const classes = useStyles();
  return (
    <AppBar position="static" className={classes.root}>
      <Toolbar>
        <Grid container alignItems="center">
          <Grid item>
            <InputBase
              placeholder="Search ..."
              startAdornment={<SearchIcon fontSize="small" />}
              className={classes.searchInput}
            />
          </Grid>
          <Grid item sm></Grid>
          <Grid item>
            <IconButton>
              <Badge badgeContent={4} color="secondary">
                <NotificationsIcon />
              </Badge>
            </IconButton>
            <IconButton>
              <Badge badgeContent={4} color="primary">
                <ChatBubbleIcon />
              </Badge>
            </IconButton>
            <IconButton>
              <SettingsIcon />
            </IconButton>
            <IconButton>
              <PowerSettingsNewIcon />
            </IconButton>
          </Grid>
        </Grid>
      </Toolbar>
    </AppBar>
  );
}
