import React, {Component} from "react";
import "./QuestionAndAnswer.css";

class QuestionAndAnswer extends Component {
    state = {
        expanded: false
    };
    
    expansionHandler = () => {
      let isExpanded = this.state.expanded;
      this.setState({expanded: !isExpanded})
    };
    
    render() {
        let output = (
            <div className="QuestionButton" onClick={this.expansionHandler}
            >{this.props.question}
            <img src="https://cdn.iconscout.com/icon/free/png-256/chevron-20-433508.png"/>
            </div>
        );
        
        if (this.state.expanded) {
            output = (
                <div onClick={this.expansionHandler}>
                    <div className="Question">{this.props.question}<img src="https://cdn.iconscout.com/icon/free/png-256/chevron-23-433511.png"/></div>
                    <div className="Answer">{this.props.answer}</div>
                </div>
            );
        }
        return output;
    }
}

export default QuestionAndAnswer;