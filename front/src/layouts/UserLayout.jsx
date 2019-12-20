
import React from "react";
import { Route, Switch } from "react-router-dom";
import { Container, Row } from "reactstrap";
import routes from "routes.js";

class UserLayout extends React.Component {

  constructor(props) {
    super(props);
    this.scrollFooter = React.createRef()
    this.state = {}
}

  
  componentDidMount() {
    document.body.classList.add("bg-default");
  }

  componentWillUnmount() {
    document.body.classList.remove("bg-default");
  }

  getRoutes = routes => {
    return routes.map((prop, key) => {
      if (prop.layout === "/user") {
        return (
          <Route
            path={prop.layout + prop.path}
            component={prop.component}
            key={key}
          />
        );
      } else {
        return null;
      }
    });
  };

  render() {

    return (
      <>
        <div className="main-content ">
          />
          <div className={ `header bg-gradient-info py-7 "py-lg-9"}`}>
            <Container>
              <div className="header-body text-center mb-3">
                <Row className="justify-content-center">
                </Row>
              </div>
            </Container>
          </div>
          {/* Page content */}
          <Container className="mt--8 pb-5">
            <Row className="justify-content-center">
              <Switch>{this.getRoutes(routes)}</Switch>
            </Row>
          </Container>
        </div>
        
      </>
    );
  }
}

export default UserLayout;
