import { ChangeEvent, useEffect, useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

function AddEditForm(props: any) {
    const [state, setState] = useState<any>({ID: 0, Name:'', Abbreviation:''});

    function onChange (event: ChangeEvent<HTMLInputElement> ) {
        setState({[event.currentTarget.name]: event.target.value});
    }

    function submitFormAdd(e: { preventDefault: () => void; }) {
        e.preventDefault();
        fetch('https://localhost:44370/api/VehicleMakes', {
            method: 'post',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({
                ID: state.ID,
                Name: state.Name,
                Abbreviation: state.Abbreviation
            })
        })
        .then(response => response.json())
        .then(item => {
            if (Array.isArray(item)) {
                props.addItemtoState(item[0]);
                props.toggle();
            }
        })
    }

    useEffect(() => {
        if(props.item) {
            const {ID, Name, Abbreviation} = props.item
            setState({ID, Name, Abbreviation})
        }
    }, [state])

    return (
        <Form onSubmit={submitFormAdd}>
            <FormGroup>
                <Label for="ID">ID</Label>
                <Input type="text" name="ID" id="ID" onChange={onChange} value={state.ID === null ? '' : state.ID} />
            </FormGroup>
            <FormGroup>
                <Label for="Name">Name</Label>
                <Input type="text" name="Name" id="Name" onChange={onChange} value={state.Name === null ? '' : state.Name} />
            </FormGroup>
            <FormGroup>
                <Label for="Abbreviation">Abbreviation</Label>
                <Input type="text" name="Abbreviation" id="Abbreviation" onChange={onChange} value={state.Abbreviation === null ? '' : state.Abbreviation} />
            </FormGroup>
            <Button onClick={submitFormAdd}>Submit</Button>
        </Form>
    )
}

export default AddEditForm;