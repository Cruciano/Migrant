import HomePage from "./pages/Home";
import PersonCreatePage from "./pages/PersonCreate";
import AidPage from "./pages/Aid";

const AppRoutes = [
  {
    index: true,
    element: <HomePage />
  },
  {
    path: '/person/create',
    element: <PersonCreatePage />
  },
  {
    path: '/aid',
    element: <AidPage />
  }
];

export default AppRoutes;
