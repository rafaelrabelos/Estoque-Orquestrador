import React from "react";
import posed from "react-pose";

const ShakeDiv =  posed.div({
  shake: {
    applyAtEnd: { x: 0 },
    applyAtStart: { x: -10 },
    x: 0,
    transition: {
      type: "spring",
      stiffness: 1000,
      damping: 10,
      duration: 4
    }
  }
});

class ShakeMe extends React.Component {

    constructor(props) {
        super(props);
        this.state = { }
    }
  
    //shake this component like a bitch :O
  render = () => <ShakeDiv pose={["shake"]} poseKey={this.props.bindValueChange} >{this.props.children}</ShakeDiv>

}
export default ShakeMe
export {ShakeDiv, ShakeMe}