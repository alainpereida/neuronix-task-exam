import React, { useEffect, useState } from 'react'
import {CONFIG} from "../../constants/app-config";
import { getToken } from "../../api/jwt.service";

const Assignments = () => {
    const [assignments, setAssignments] = useState([])
    
    useEffect(() => {
        fetch(CONFIG.API_HOST + '/api/assignment',{
            headers: {
               'Authorization': `Bearer ${getToken()}`
            }
        })
        .then((response) => {
            return response.json()
        }).then((assignmentsList) => {
            setAssignments(assignmentsList) 
        })
    }, []);
    
    return (
        <div id="assignments-list-root">

        </div>
    )
}

export default Assignments;
