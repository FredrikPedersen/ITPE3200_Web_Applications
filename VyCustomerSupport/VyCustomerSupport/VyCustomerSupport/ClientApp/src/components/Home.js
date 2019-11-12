import React, {Component} from 'react';

export class Home extends Component {
    static displayName = Home.name;


    constructor(props) {
        super(props);

        this.state = {
            qas: []
        };

        fetch("api/index/qas")
            .then(response => response.json())
            .then(qas => {
                this.setState({qas: qas});
                console.log(this.state.qas);
            });
        
    }

  render() {
        return (
            <div>
                <h1>Hello, world!</h1>
            </div>
        );
    }
}
