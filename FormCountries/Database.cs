using claseLogica;
namespace FormCountries

{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
            cargarDatos();
        }
        CountriesDAO countriesDAO = new CountriesDAO();
        OfficesDAO officesDAO = new OfficesDAO();
        RolesDAO rolesDAO = new RolesDAO();
        public void cargarDatos()
        {
            try
            {
         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
