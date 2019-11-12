import React, {Component} from 'react';
import "../../Styles.css";

import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";

export class FAQ extends Component {
    static displayName = FAQ.name;


    constructor(props) {
        super(props);

        this.state = {
            qas: [],
            loading: false,
            error: false
        };

        fetch("api/index/qas")
            .then(response => response.json())
            .then(qas => {
                this.setState({qas: qas});
            })
            .catch(error => {
                this.setState({error: true});
            })
        
    }

  render() {
      let qas = this.state.error? <p className="ErrorMessage">FAQs can't be loaded. Please check your Internet connection!</p> : <LoadingSpinner/>; 
        
        return (
            <div>
                {qas}
            </div>
        );
    }
}
