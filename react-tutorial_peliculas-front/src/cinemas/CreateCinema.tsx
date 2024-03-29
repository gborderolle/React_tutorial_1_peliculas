import axios from "axios";
import FormCinema from "./FormCinema";
import { cinemaCreationDTO } from "./cinema.model";
import { urlCinemas } from "../utils/endpoints";
import { useNavigate } from "react-router-dom";
import ShowErrors from "../utils/ShowErrors";
import { useState } from "react";
import showToastMessage from "../messages/ShowSuccess";
import { handleErrors } from "../utils/HandleErrors";

export default function CreateCinema() {
  const navigate = useNavigate(); // sirve para navegar entre las páginas
  const [errors, setErrors] = useState<string[]>([]);

  async function createCinema(cinema: cinemaCreationDTO) {
    try {
      const url_values = urlCinemas;
      const config_values = {
        headers: {
          "x-version": "2",
        },
      };
      await axios.post(url_values, cinema, config_values);

      showToastMessage({
        title: "Creación correcta",
        icon: "success",
        callback: () => {
          navigate("/cinemas");
        },
      });
    } catch (error: any) {
      handleErrors(error, setErrors);
    }
  }

  return (
    <>
      <ShowErrors errors={errors} />
      <FormCinema
        formName="Crear cine"
        model={{ name: "" }}
        onSubmit={async (values) => {
          await createCinema(values);
        }}
      />
    </>
  );
}
