import React, {Component} from "react";
import axios from "axios";
import AddCousine from "./add-cousine";
import { NavLink, Route } from "react-router-dom";

class CousinePage extends Component {
  state = {
    CousineData: []  
  };
  
  componentDidMount() {  
    axios.get("https://localhost:44388/api/Cousines", {
      method: 'GET',
      // headers: {
      //   'Access-Control-Allow-Origin': '*',
      //   'Content-Type': 'application/json',
      // }
    }).then(response => {  
      console.log(response.data);  
      debugger; 
        this.setState({  
          CousineData: response.data  
        });  
    });  
  }

  render() {
     return ( <section>  
            <Route path="/cousine" component={AddCousine} />
        <h1>
          Cousine List        

  
           {/* <NavLink to="/add-cousine" className="btn btn-primary"> Add </NavLink > */}
        </h1>  
        <div>  
            <table>  
                <thead>
                    <tr>
                      <th>Nr. </th>
                      <th>Cousine Name</th>
                      <th></th>
                      <th></th>
                      <th></th>

                    </tr>
                </thead>  
                <tbody>  
                    {  
                        this.state.CousineData.map((p, index) => {  
                            return <tr key={index}>
                              <td>{p.id}</td>
                              <td> {p.cousineName}</td>
                              <td><NavLink> Info </NavLink> </td> | 
                              <td><NavLink> Edit </NavLink> </td> | 
                              <td><NavLink> Delete </NavLink> </td>

                            </tr>;  
                        })  
                    }  
                </tbody>  
            </table>  
        </div>  
      </section>  
     )
  }
}

export default CousinePage;


