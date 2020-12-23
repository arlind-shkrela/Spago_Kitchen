import React, { useState, Component } from "react";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";
import DishDataService from "../services/dish.service";

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
        >
          <DialogTitle id="form-dialog-title">{dialogName}</DialogTitle>
          <DialogContent>
            <TextField
              autoFocus
              margin="dense"
              id="name"
              value={this.state.name}
              onChange={this.handleChange}
              label="Dish Name"
              type="text"
              fullWidth
            />
            {/* <NumberField
              margin="dense"
              id="name"
              label="Email Address"
              type="email"
              fullWidth
            /> */}
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
