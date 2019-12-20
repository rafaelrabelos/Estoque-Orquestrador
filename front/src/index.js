import React from 'react';
import ReactDOM from 'react-dom';
import { Route, Redirect, BrowserRouter, Switch} from 'react-router-dom';
import { positions, Provider } from "react-alert";
import AlertTemplate from "react-alert-template-basic";
import UserLayout from "layouts/UserLayout.jsx";



import "assets/vendor/nucleo/css/nucleo.css";
import "assets/vendor/@fortawesome/fontawesome-free/css/all.min.css";
import "assets/scss/argon-dashboard-react.scss";

const options = {
    timeout: 5000,
    position: positions.BOTTOM_CENTER,
};

const routing = (
    <Provider template={AlertTemplate} {...options}>
        <BrowserRouter basename={"/estorquestrador"}>
            <Switch>
                <Route path="/user" render ={props => <UserLayout {...props} />} />
                <Redirect from="/" to="/user/Home" />
            </Switch>
        </BrowserRouter>
    </Provider>
)

ReactDOM.render(routing, document.getElementById('root'));
