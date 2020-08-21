
import React from "react";
import { Collapse, Spinner} from "reactstrap";
import { isFunction } from "util";

class CollapseItem extends React.Component {

    constructor(props) {
        super(props);

        this.state = { Content : <Spinner type="grow" /> }
    }

    onEntering = () => this.setState({ Content : <Spinner type="grow" size="sm" /> });
    onEntered = () => this.setState({ Content : this.props.Content});
    onExiting = () => this.setState({ Content : <Spinner type="grow" size="sm" /> });
    onExited = () => this.setState({ Content : this.props.Content });
    
    componentDidMount = () => this.setState({Content : this.props.Content});

    CollapseItem = () => <Collapse 
                    isOpen={this.props.isOpen}
                    onEntering={() => this.onEntering()}
                    onEntered={() => this.onEntered()}
                    onExiting={() => this.onExiting()}
                    onExited={() => this.onExited()}
                >
                    { this.props.children }
                    
                </Collapse>

    render = () => this.CollapseItem();

}
export default CollapseItem;
