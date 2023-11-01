import { Home } from "../layouts/default/Home";
import Login from "../views/login/Login";
import Assignments from "../views/assignments/Assignments";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/login',
    element: <Login />
  },
  {
    path: '/assignments',
    element: <Assignments />
  }
];

export default AppRoutes;
