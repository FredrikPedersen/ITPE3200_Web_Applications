import React, {Component} from "react";

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
            </div>
        );
        
        if (this.state.expanded) {
            output = (
                <div onClick={this.expansionHandler}>
                    <div className="Question">{this.props.question}</div>
                    <div className="Answer">{this.props.answer}</div>
                </div>
            );
        }
        return output;
    }
}

export default QuestionAndAnswer;