import React, {Component} from 'react';
import "../../Styles.css";
import "./FAQ.css"

import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";
import Headline from "../../components/Headline/Headline";
import QuestionButton from "../../components/UI/QuestionButton/QuestionButton";

const FAQ_INFO_TEXT = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";

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
    
    qaContent() {
        
        let questionButtons = [];
        
        for (let qa in this.state.qas) {
            questionButtons.push(
                <QuestionButton 
                key={this.state.qas[qa].id}
                >{this.state.qas[qa].question}
                </QuestionButton>
            )
        }
        
        return(
          <div>
              {questionButtons}
          </div>  
        );
    }

    render() {
        let qas = this.state.error ?
            <p className="ErrorMessage">FAQs can't be loaded. Please check your Internet connection!</p> :
            <LoadingSpinner/>;

        if (this.state.qas) {
            qas = this.qaContent();
        }
        return (
            <div className="ContentArea">
                <Headline
                    infoText={FAQ_INFO_TEXT}
                >Frequently Asked Questions</Headline>
                {qas}
            </div>
        );
    }
}
