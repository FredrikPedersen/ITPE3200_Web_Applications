import React, {Component} from 'react';
import styles from "./FAQ.css";

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
      let qas = this.state.error? <p className={styles.ErrorMessage}>FAQs can't be loaded. Please check your Internet connection!</p> : <p className={styles.ErrorMessage}>LET'S DO THIS</p>
        
        return (
            <div>
                {qas}
            </div>
        );
    }
}
