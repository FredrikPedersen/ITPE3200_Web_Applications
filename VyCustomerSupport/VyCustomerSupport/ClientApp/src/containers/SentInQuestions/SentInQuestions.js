import React, {Component} from "react";
import "../../Styles.css";
import Header from "../../components/UI/Header/Header";

export class SentInQuestions extends Component {
    
    constructor(props)  {
        super(props);
    }
    
    render() {
        return(
            <div className="ContentArea">
                <Header
                    infoText="Her kan du se brukerinnsendte spørsmål. De med flest positive stemmer vil først bli besvart og lagt til på FAQ-siden"
                >Innsendte Spørsmål</Header>
            </div>
        )
    }
}