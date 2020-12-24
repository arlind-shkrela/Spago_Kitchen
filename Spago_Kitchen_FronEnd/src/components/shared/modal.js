import React, { useState, Component } from "react";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";
import DishDataService from "../services/dish.service";
import { Grid } from "@material-ui/core";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";

export default class FormDialog extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: "",
      calories: 0,
      protein: 0,
      description: "hi there",
      cousineId: 1,
      cookingTimeId: 1,
      categoryId: 1,
      price: 0,
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleClose = this.handleClose.bind(this);
    this.AddNewDish = this.AddNewDish.bind(this);

    //let [openDialog, setOpen] = useState(false);
  }
  handleChange(event) {
    this.setState({ name: event.target.value });
  }
  handleCousineIdChange(event) {
    this.setState({ cousineId: event.target.value });
  }
  handleClose() {
    this.setState({
      setOpen: false,
    });
    //open =;
    // setOpen(false);
  }

  AddNewDish() {
    DishDataService.create(this.state)
      .then((response) => {
        this.setState({
          name: "",
        });
        this.setOpen = false;
        console.log(this.rows);
      })
      .catch((e) => {
        console.log(e);
      });
  }

  render() {
    const { open, dialogName } = this.props;
    return (
      <div>
        <Dialog
          open={open}
          onClose={this.handleClose}
          aria-labelledby="form-dialog-title"
          paperWidthLg="lg"
        >
          <DialogTitle id="form-dialog-title">{dialogName}</DialogTitle>
          <DialogContent>
            <Grid container alignItems="center">
              <Grid item xs={12} sm={6}>
                <TextField
                  autoFocus
                  margin="dense"
                  id="name"
                  name="name"
                  value={this.state.name}
                  onChange={this.handleChange}
                  label="Dish Name"
                  type="text"
                  fullWidth
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                {" "}
                <Select
                  labelId="demo-simple-select-helper-label"
                  id="demo-simple-select-helper"
                  value={this.state.categoryId}
                  name="cousineId"
                  onChange={this.handleCousineIdChange}
                >
                  <MenuItem value="">
                    <em>None</em>
                  </MenuItem>
                  <MenuItem value={10}>Ten</MenuItem>
                  <MenuItem value={20}>Twenty</MenuItem>
                  <MenuItem value={30}>Thirty</MenuItem>
                </Select>
              </Grid>
            </Grid>
          </DialogContent>
          <DialogActions>
            <Button onClick={this.handleClose} color="primary">
              Cancel
            </Button>
            <Button onClick={this.AddNewDish} color="primary">
              Add
            </Button>
          </DialogActions>
        </Dialog>
      </div>
    );
  }
}
