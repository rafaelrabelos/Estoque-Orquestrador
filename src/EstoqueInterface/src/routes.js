
import Home from "views/Home.jsx";


var routes = [].concat( [
  {
    path: "/Home",
    name: "Home",
    icon: "ni ni-key-25",
    component: Home,
    layout: "/user",
    showInSideBar: false
  },
]);
export default routes;
export { routes, }
