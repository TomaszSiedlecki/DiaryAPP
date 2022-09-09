import { Link } from "react-router-dom";

const Navigation = () => {
    const user =  localStorage.getItem('user-data');
    return(
        <>
            <nav className="navbar navbar-expand-lg navbar-light navbar-diary">
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav ">
                        <li className="nav-item ">
                            <a className="nav-link text-diary" href="Grades">Grades</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link text-diary" href="About">About</a>
                        </li>
                        {user ?
                            <li className="nav-item">
                                <a className="nav-link text-diary" href="Logout">Logout</a>
                            </li>
                            :
                            <li className="nav-item">
                                <a className="nav-link text-diary" href="Login">Login</a>
                            </li>
                        }
                        </ul>
                    </div>
            </nav>
        </>
    );
};

export default Navigation;