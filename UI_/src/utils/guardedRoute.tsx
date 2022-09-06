import { Navigate, Outlet } from "react-router";

const GuardedRoutes = () => {
    const user =  localStorage.getItem('user-data');
    console.log(user);
    return(
        user ? <Outlet/> : <Navigate to={'/login'}/>
    )
}

export default GuardedRoutes;

