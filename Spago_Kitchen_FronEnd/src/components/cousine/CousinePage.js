import React from "react";
import axios from "axios";

class CousinePage extends React.Component {
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
        <h1>Cousine List</h1>  
        <div>  
            <table>  
                <thead><tr><th>Cousine Id</th><th>Cousine Name</th></tr></thead>  
                <tbody>  
                    {  
                        this.state.CousineData.map((p, index) => {  
                            return <tr key={index}><td>{p.id}</td><td> {p.cousineName}</td></tr>;  
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


