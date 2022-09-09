import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { useEffect, useState } from "react";
import { IMessage } from "../../models/message";
import { Api } from "../../services/main.service";
//import { MessageHubType } from "../../models/messageType";

const Grades = () =>{
    const api = new Api();
    interface IUserGrades{
        key: string,
        value: string
    };

    const [subject, setSubject] = useState('');
    const [subjects, setSubjects] = useState<string[]>([]);
    const [grades, setGrades] = useState<IUserGrades[]>([]);
    const [studentID, setStudentID] = useState();

    const [connection, setConnection ] = useState<HubConnection>();
 

    useEffect(() => {
        const rawUser = localStorage.getItem('user-data');
        if(rawUser){
            const user = JSON.parse(rawUser);
            const username = user['username'];
            const surname = user['surname'];
            const classID = user['classID'];
            const studentID = user['studentID'];
            
            setStudentID(studentID);

            api.getStudentAllGrades.getStudentAllGradesCreate({StudentID:studentID})
            .then((res:any) => {
                setGrades(res.data.studentGrades);
            });

            const newConnection = new HubConnectionBuilder()
                .withUrl("http://localhost:2653/messagehub?value="+username+"?"+surname+"?"+classID+"?"+studentID
                , { withCredentials: true, headers:{
                    'Access-Control-Allow-Origin':'*',
                }})
                .withAutomaticReconnect()
                .build();
            setConnection(newConnection);

        };
        const unique = Array.from(new Set(grades?.map(item => item.key)));
        setSubjects(unique);
    },[]);

    useEffect(() => {
        if (connection) {
             connection.start()
                 .then(result => {
                     connection.on('ReceiveMessage', (message:IMessage) => {
                        console.log("New grade", message);
                        api.getStudentAllGrades.getStudentAllGradesCreate({StudentID:studentID})
                        .then((res:any) => {
                            setGrades(res.data.studentGrades);
                        });
                     });
                 })
                 .catch(e => console.log('Connection failed: ', e));
         }
     }, [connection]);
 

    useEffect(() => {
        console.log(subject)
        if(subject && subject != 'All')
        {
            setGrades([...grades.filter(c => c.key == subject)]);
        }else{
            const rawUser = localStorage.getItem('user-data');
            if(rawUser){
                const user = JSON.parse(rawUser);
                const studentID = user['studentID'];
                api.getStudentAllGrades.getStudentAllGradesCreate({StudentID:studentID})
                .then((res:any) => {
                    console.log(res.data.studentGrades);
                    setGrades(res.data.studentGrades);
                });   
            }
        }
    },[subject])

    return(
        <>
        <div className="row container mt-2">
            <div className="col-6 m-3">
                <div className="input-group ">
                    <select onChange={(e)=>setSubject(e.target.value)} className="filter-select" id="inputGroupSelect04">
                        <option selected>All</option>
                        {subjects.map(i =>(
                        <option value={i}>{i}</option>
                    ))}
                    </select>
                </div>
            </div>
        </div>
        <div className={"m-4"}>
            <table className="mt-2 table">
                    <thead className="thead-light">
                        <tr>
                        <th scope="col">#</th>
                        <th scope="col">Subject</th>
                        <th scope="col">Grade</th>
                        </tr>
                    </thead>
                    <tbody>
                        {grades?.map((i,index) =>(
                            <tr>
                            <th scope="row">{index}</th>
                            <td>{i.key}</td>
                            <td>{i.value}</td>
                            </tr>

                        ))}
                        
                    </tbody>
                </table>
        </div>
        </>
    );
};
export default Grades;
