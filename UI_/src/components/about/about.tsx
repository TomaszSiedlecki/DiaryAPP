import { useEffect, useState } from "react";
import { Api, UserResponse } from "../../services/main.service";

const About = () => {
    const [about, setAbout] = useState<UserResponse>();
    const api = new Api();
    const rawUser = localStorage.getItem('user-data');
    if(rawUser)
    {
        const user = JSON.parse(rawUser);
    }
    useEffect(() => {
        const fetchData = async () => {
            const rawUser = localStorage.getItem('user-data');
            if(rawUser)
            {
                const user = JSON.parse(rawUser);
                const aboutData = await api.api.userGetUserCreate({firstName: user['username'], secondName:user['surname']});
                if(aboutData.data){
                    setAbout(aboutData.data);
                    
                }
            }
        }
        fetchData();
    },[])
    return(
        <>
           <div className="mt-5 card text-center">
                <div className="card-header">
                    About you
                </div>
                <div className="card-body">
                    <div className="row">
                        <div className="col-3">
                            <div className="card-body">
                                <h5 className="card-title">Tomasz Siedlecki</h5>
                                <p className="card-text">30-139 Kraków, ul. Niebieska 20/3</p>
                                <p className="card-text">123@123.pl</p>
                            </div>
                        </div>
                        <div className="col-3">
                            <div className="card-body">
                                <h5 className="card-title">Born date</h5>
                                <p className="card-text">1997-05-25</p>
                            </div>
                        </div>
                        <div className="col-3">
                            <div className="card-body">
                                <h5 className="card-title">Role</h5>
                                <p className="card-text">Student</p>
                            </div>
                        </div>
                        <div className="col-3">
                            <div className="card-body">
                                <h5 className="card-title">Class</h5>
                                <p className="card-text">1a</p>
                                <a href="/grades" className="btn btn-primary">Show grades</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};
export default About;