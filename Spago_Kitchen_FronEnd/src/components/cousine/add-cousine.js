import React, {Component} from "react";
import CousineDataService from "../services/cousine.service"

export default class AddCousine extends Component {
    constructor(props) {
        super(props);
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.saveCousine = this.saveCousine.bind(this);
        this.newCousine = this.newCousine.bind(this);
    
        this.state = {
          id: null,
          cousineName: "",
          submitted: false
        };
      }
      onChangeTitle(e) {
        this.setState({
            cousineName: e.target.value
        });
      }
      saveCousine() {
        var data = {
            cousineName: this.state.cousineName,
        
        };
    
        CousineDataService.create(data)
          .then(response => {
            this.setState({
              id: response.data.id,
              cousineName: response.data.cousineName,
              submitted: true
            });
            console.log(response.data);
          })
          .catch(e => {
            console.log(e);
          });
      }
    
      newCousine() {
        this.setState({
          id: null,
          cousineName: "",
          submitted: false
        });
      }

    render() {
      return (
        <div className="submit-form">
          {this.state.submitted ? (
            <div>
              <h4>You submitted successfully!</h4>
              <button className="btn btn-success" onClick={this.newCousine}>
                Add
              </button>
            </div>
          ) : (
              <div>
              <label htmlFor="cousineName">Add New</label>
              <div className="form-group">
                <input
                  type="text"
                  className="form-control"
                  id="title"
                  required
                  value={this.state.cousineName}
                  onChange={this.onChangeTitle}
                  name="title"
                />
              </div>
  
              <button onClick={this.saveCousine} className="btn btn-success">
                Submit
              </button>
            </div>
          )}
        </div>
      );
    }
  }