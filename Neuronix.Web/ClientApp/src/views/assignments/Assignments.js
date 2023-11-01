import React, { useEffect, useState } from 'react'
import {CONFIG} from "../../constants/app-config";
import { getToken } from "../../api/jwt.service";
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Grid from "@mui/material/Grid";
import TextField from "@mui/material/TextField";
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import ListItemText from '@mui/material/ListItemText';
import Avatar from '@mui/material/Avatar';
import IconButton from '@mui/material/IconButton';
import AssignmentIcon from '@mui/icons-material/Assignment';
import DeleteIcon from '@mui/icons-material/Delete';
import Checkbox from "@mui/material/Checkbox";

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

const Assignments = () => {
    const [assignments, setAssignments] = useState([])
    const [openCreateModal, setOpenCreateModal] = useState(false)
    const [openDeleteModal, setOpenDeleteModal] = useState(false)
    const [idDelete, setIdDelete] = useState(0)
    const [description, setDescription] = useState('')
    const handleOpen = () => setOpenCreateModal(true);
    const handleClose = () => setOpenCreateModal(false);

    const handleOpenDelete = (element) => {
        setIdDelete(element.id)
        setOpenDeleteModal(true);
    }
    const handleCloseDelete = () => setOpenDeleteModal(false);
    
    const handleIsCompleted = async (assigment) => {
        assigment.isCompleted = !assigment.isCompleted;
        await fetch(CONFIG.API_HOST + '/api/assignment/' + assigment.id + '/change-status?isCompleted=' + assigment.isCompleted,{
            method: 'PATCH',
            headers: {
                'Authorization': `Bearer ${getToken()}`
            }
        });
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
    }
    
    const handleCreate = async () => {
        const responseCreate = await fetch(CONFIG.API_HOST + '/api/assignment',{
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${getToken()}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                description
            })
        });
        const assignmentCreated = await responseCreate.json();
        assignments.unshift(assignmentCreated);
        setOpenCreateModal(false);
    }

    const handleDelete = async () => {
        await fetch(CONFIG.API_HOST + '/api/assignment/' + idDelete,{
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${getToken()}`
            }
        });
        let removeIndex = assignments.findIndex((assingment) => assingment.id === idDelete);
        delete assignments[removeIndex];
        setOpenDeleteModal(false);
        setIdDelete(0);
    }
    
    const showListAssignments = () => {
        return (
            <div id="list-assignments">
                <List>
                    { assignments.map((assigment) => {
                        return (
                            <ListItem
                                secondaryAction={
                                    <IconButton onClick={() => handleOpenDelete(assigment)} edge="end" aria-label="delete">
                                        <DeleteIcon />
                                    </IconButton>
                                }
                                key={assigment.id}
                            >
                                <ListItemAvatar>
                                    <Avatar>
                                        <AssignmentIcon />
                                    </Avatar>
                                </ListItemAvatar>
                                <ListItemText
                                    primary={assigment.description}
                                />
                                <Checkbox
                                    edge="end"
                                    checked={assigment.isCompleted}
                                    onChange={() => handleIsCompleted(assigment)}
                                />
                            </ListItem>
                        )
                    })}
                </List>
            </div>
        );
    }
    
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
            <Grid container spacing={2}>
                <Grid item xs={8}>
                    <h1>Tus lista de tareas</h1>
                </Grid>
                <Grid item xs={4}>
                    <Button variant="contained" onClick={handleOpen}>Agregar tarea</Button>
                </Grid>
            </Grid>

            { assignments.length === 0 ? (
                <div> No se encontraron tareas para mostrar</div>
            ) : showListAssignments() }

            {/* Modal Created */}
            <Modal
                open={openCreateModal}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        Crear una tarea nueva
                    </Typography>
                    <TextField 
                        className="w-100"
                        id="description-task" 
                        label="Descripción de la tarea" 
                        variant="outlined" 
                        value={description}
                        onChange={(event) => {
                            setDescription(event.target.value);
                        }}/>
                    <div className="d-flex justify-content-end m-2">
                        <Button variant="contained" onClick={handleCreate}>Crear</Button>
                    </div>
                </Box>
            </Modal>

            {/* Modal Deleted */}
            <Modal
                open={openDeleteModal}
                onClose={handleCloseDelete}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        Estas seguro que deseas eliminar la tarea?
                    </Typography>

                    <div className="d-flex justify-content-end m-2">
                        <Button className="m-2" variant="outlined" onClick={handleCloseDelete}>Cancelar</Button>
                        <Button className="m-2" variant="contained" onClick={handleDelete}>Eliminar</Button>
                    </div>
                </Box>
            </Modal>
        </div>
    )
}

export default Assignments;
