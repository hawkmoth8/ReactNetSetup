import React, { Component } from "react";
import {
  BrowserRouter,
  Link,
  Route,
  Switch,
  StaticRouter
} from "react-router-dom";
import PropTypes from "prop-types";

class RrouterExample extends Component {
  render() {
    const Navbar = (
      <ul>
        <li>
          <Link to="/privacy">privacy</Link>
        </li>
        <li>
          <Link to="/page1">page1</Link>
        </li>
        <li>
          <Link to="/page2">page2</Link>
        </li>
      </ul>
    );
    // const history = createMemoryHistory();

    const app = (
      <fragment>
        {Navbar}
        <Switch>
          <Route exact path="/privacy">
            <div>this is privacy</div>
          </Route>
          <Route exact path="/page1">
            <div>this is page1</div>
          </Route>
          <Route exact path="/page2">
            <div>this is page2</div>
          </Route>
          {/* <Route>
            <Redirect to="/page1" />
          </Route> */}
        </Switch>
      </fragment>
    );

    const { context, location } = this.props;
    if (typeof window === "undefined") {
      return (
        <StaticRouter context={context} location={location}>
          {app}
        </StaticRouter>
      );
    }
    return <BrowserRouter>{app}</BrowserRouter>;
  }
}

RrouterExample.propTypes = {
  context: PropTypes.string,
  location: PropTypes.string
};

RrouterExample.defaultProps = {
  context: "",
  location: ""
};

export default RrouterExample;
