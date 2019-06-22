using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoVania
{
    class Program
    {
        static void Main(string[] args)
        {

            //Variáveis para o cadastro
            int escolha = 0;


            Empresa e1 = new Empresa();




            while (escolha != 11)
            {
                string cpf, cnpj;
                Console.WriteLine("0  - Cadastrar uma Empresa");
                Console.WriteLine("1  - Cadastrar um funcionario");
                Console.WriteLine("2  - Exibir todos os funcionarios");
                Console.WriteLine("3  - Alterar todos dados de um funcionario com determinado CPF");
                Console.WriteLine("4  - Conceder aumento para determinado funcionario");
                Console.WriteLine("5  - Exibir salario de todos funcionarios");
                Console.WriteLine("6  - Buscar um funcionario pelo CPF");
                Console.WriteLine("7  - Exibir ganhos anuais de todos funcionarios");
                Console.WriteLine("8  - Exibir todas as empresas");
                Console.WriteLine("9  - Alterar dados da empresa");
                Console.WriteLine("10 - Exibir funcionarios com salario extra");
                Console.WriteLine("11 - Sair do sistema");

                escolha = Convert.ToInt32(Console.ReadLine());
                if (escolha == 1)
                {
                    e1.CadastroFuncionario();

                }
                else if (escolha == 0)
                {
                    e1.CadastroEmpresa();
                }
                else if (escolha == 2)
                {
                    e1.ListaFuncionarios();

                }
                else if (escolha == 3)
                {
                    Console.WriteLine("Digite o CPF do funcionario que deseja alterar os dados");
                    cpf = Console.ReadLine();


                    e1.AlterarFuncionarios(cpf);
                }
                else if (escolha == 4)
                {
                    Console.WriteLine("Digite o cpf do funcionario que deseja realizar o aumento");
                    cpf = Console.ReadLine();
                    e1.AumentoSalario(cpf);
                }
                else if (escolha == 5)
                {
                    e1.MostraSalarios();
                }
                else if (escolha == 6)
                {
                    Console.WriteLine("Digite o cpf do funcionário que deseja encontrar");
                    cpf = Console.ReadLine();
                    e1.BuscaFuncionario(cpf);
                }
                else if (escolha == 7)
                {
                    e1.GanhosAnuais();
                }
                else if (escolha == 8)
                {
                    e1.ListaEmpresas();
                }
                else if (escolha == 9)
                {
                    Console.WriteLine("Digite o cnpj da empresa que quer alterar os dados");
                    cnpj = Console.ReadLine();
                    e1.AlteraEmpresa(cnpj);
                }
                else if (escolha == 10)
                {
                    e1.ListaComExtras();
                }
            }
        }
    }

    interface ISalarioExtra
    {
        void CalculaExtra(double carga);
    }
    public class Funcionario : ISalarioExtra
    {

        
        public string Cpf { get; set; }
        public double CargaH { get; set; }
        public string Rg { get; set; }        
        public double Salario { get; set; }
        public string Nome { get; set; }
        public string Dept { get; set; }
        public bool Aumento { get; set; }
        public string Turno { get; set; }
        public void CalculaExtra(double carga)
        {
            if (Dept == "Vendas")
            {
                if (carga <= 10)
                {
                    { Salario += 75; }
                }
                else if (carga > 10 && carga <= 15)
                {
                    Salario += 100;
                }
                else if (carga > 15 && carga <= 20)
                {
                    Salario += 150;
                }
                else if (carga > 20 && carga <= 25)
                {
                    Salario += 200;
                }
                else if (carga > 25) {
                    Salario += 150;
                }
                Console.WriteLine("O salario do funcionario " + Nome + " foi reajustado para " + Salario + " por conta da carga horaria do mesmo.");

            }

        }

    }
    class Empresa
    {
        
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }

        List<Empresa> Empresas = new List<Empresa>();
        List<Funcionario> Funcionarios = new List<Funcionario>();


        public Empresa() { }

        public void CadastroEmpresa()
        {
            {
                string nome, razao, cnpj;
                Console.WriteLine("Entre com o nome da empresa");
                nome = Console.ReadLine();

                Console.WriteLine("Entre com a razao social da empresa");
                razao = Console.ReadLine();

                Console.WriteLine("Digite o cnpj da empresa");
                cnpj = Console.ReadLine();

                Empresa empresa1 = new Empresa()
                {
                    Nome = nome,
                    RazaoSocial = razao,
                    Cnpj = cnpj,
                };
                Empresas.Add(empresa1);
            }
        }

        public void CadastroFuncionario()
        {
            string nome, rg, cpf, dept, turno = " ";
            double salario, carga = 0;
            Console.WriteLine("Entre com o nome");
            nome = Console.ReadLine();

            Console.WriteLine("Entre com o RG");
            rg = Console.ReadLine();

            Console.WriteLine("Digite o cpf do funcionário");
            cpf = Console.ReadLine();

            Console.WriteLine("Digite o salario do funcionário");
            salario = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Em qual departamento ele trabalha");
            dept = Console.ReadLine();

            if (dept == "Producao" || dept == "producao" || dept == "Produção" || dept == "produção")
            {
                dept = "Producao";
                Console.WriteLine("Entre com o turno dele");
                turno = Console.ReadLine();
            }

            if (dept == "Vendas" || dept == "vendas" || dept == "venda" || dept == "Venda")
            {
                dept = "Vendas";
                Console.WriteLine("Digite a carga horaria do funcionario");
                carga = Convert.ToDouble(Console.ReadLine());
            }

            Funcionario funcionario1 = new Funcionario()
            {
                Nome = nome,
                Rg = rg,
                Turno = turno,
                CargaH = carga,
                Dept = dept,
                Salario = salario,
                Cpf = cpf,
                Aumento = false
            };
            funcionario1.CalculaExtra(funcionario1.CargaH);
            Funcionarios.Add(funcionario1);
            
        }

        public void ListaEmpresas()
        {
            bool isEmpty = !Empresas.Any();
            if (isEmpty)
            {
                Console.WriteLine("NAO TEM EMPRESAS CADASTRADAS NO SISTEMA");
            }
            else
            {
                foreach (Empresa empr in Empresas)
                {
                    Console.WriteLine("Nome: " + empr.Nome);
                    Console.WriteLine("Razao social: " + empr.RazaoSocial);
                    Console.WriteLine("CNPJ: " + empr.Cnpj);
                    Console.WriteLine("\n");
                }
            }
        }
        public void ListaFuncionarios()
        {
            bool isEmpty = !Funcionarios.Any();
            if (isEmpty)
            {
                Console.WriteLine("NAO TEM FUNCIONARIOS CADASTRADOS NO SISTEMA");
            }
            else
            {

                foreach (Funcionario func in Funcionarios)
                {
                    
                    Console.WriteLine("Nome: " + func.Nome);
                    Console.WriteLine("Rg: " + func.Rg);
                    Console.WriteLine("Salario: " + func.Salario);
                    Console.WriteLine("Departamento: " + func.Dept);
                    if (func.Dept == "Producao")
                        Console.WriteLine("Turno: " + func.Turno);
                    if (func.Dept == "Vendas")
                        Console.WriteLine("Carga Horaria: " + func.CargaH);
                    Console.WriteLine("Cpf: " + func.Cpf);
                    Console.WriteLine("\n");

                }
            }
        }
        public void MostraSalarios()
        {

            bool isEmpty = !Funcionarios.Any();
            if (isEmpty)
            {
                Console.WriteLine("NAO TEM FUNCIONARIOS CADASTRADOS NO SISTEMA");
            }
            else
            {
                foreach (Funcionario func in Funcionarios)
                {
                    Console.WriteLine("Nome: " + func.Nome);
                    Console.WriteLine("Salario: " + func.Salario);
                    Console.WriteLine("\n");
                }
            }
        }



        public void AlterarFuncionarios(string cpf)
        {
            int aux = 0;
            bool isEmpty = !Funcionarios.Any();
            if (isEmpty)
            {
                Console.WriteLine("NAO TEM FUNCIONARIOS CADASTRADOS NO SISTEMA");
            }
            else
            {
                foreach (Funcionario func in Funcionarios)
                {
                    if (cpf == func.Cpf)
                    {
                        Console.WriteLine("Digite o novo nome");
                        func.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o novo cpf");
                        func.Cpf = Console.ReadLine();
                        Console.WriteLine("Digite o novo rg");
                        func.Rg = Console.ReadLine();
                        Console.WriteLine("Digite o novo salario");
                        func.Salario = float.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o novo Departamento");
                        func.Dept = Console.ReadLine();
                        if (func.Dept == "Producao" || func.Dept == "producao" || func.Dept == "Produção" || func.Dept == "produção")
                        {
                            func.Dept = "Producao";
                            Console.WriteLine("Entre com o turno");
                            func.Turno = Console.ReadLine();
                        }
                        if (func.Dept == "Vendas" || func.Dept == "vendas" || func.Dept == "venda" || func.Dept == "Venda")
                        {
                            func.Dept = "Vendas";
                            Console.WriteLine("Digite a carga horaria do funcionario");
                            func.CargaH = Convert.ToDouble(Console.ReadLine());
                        }
                        aux += 1;
                    }

                }
                if (aux == 0)
                    Console.WriteLine("Nao foi encontrado esse cpf no sistema.");
            }
        }

        public void AlteraEmpresa(string cnpj)
        {
            int aux = 0;
            bool isEmpty = !Empresas.Any();
            if (isEmpty)
            {
                Console.WriteLine("NAO TEM EMPRESAS CADASTRADAS NO SISTEMA");
            }
            else
            {
                foreach (Empresa empr in Empresas)
                {
                    if (cnpj == empr.Cnpj)
                    {
                        Console.WriteLine("Digite o novo nome");
                        empr.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o novo CNPJ");
                        empr.Cnpj = Console.ReadLine();
                        Console.WriteLine("Digite a nova Razao social");
                        empr.RazaoSocial = Console.ReadLine();
                        aux += 1;
                    }

                }
                if (aux == 0)
                    Console.WriteLine("Nao foi encontrado esse cnpj no sistema.");
            }
        }

        public void AumentoSalario(string cpf)
        {
            double porcentagem_aumento = 0;
            int aux = 0;

            foreach (Funcionario func in Funcionarios)
            {
                if (func.Cpf == cpf)
                {
                    Console.WriteLine("Quanto quer dar de aumento? (Porcentagem)");
                    porcentagem_aumento = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Salario antigo: " + func.Salario);
                    porcentagem_aumento /= 100;
                    porcentagem_aumento += 1;
                    func.Salario *= porcentagem_aumento;
                    Console.WriteLine("Novo salario: " + func.Salario);
                    Console.WriteLine("\n");
                    aux++;

                }
            }

            if (aux == 0)
                Console.WriteLine("CPF nao foi encontrado no sistema!");

        }

        public double calculaGanhoAnual(string cpf)
        {
            double Ganho_anual = 0;
            int aux = 0;
            bool isEmpty = !Funcionarios.Any();
            if (isEmpty)
            {
                Console.WriteLine("NAO TEM FUNCIONARIOS CADASTRADOS NO SISTEMA");
            }
            else
            {
                foreach (Funcionario func in Funcionarios)
                {
                    if (cpf == func.Cpf)
                    {
                        Ganho_anual = func.Salario * 12;
                        return Ganho_anual;
                    }
                }
                if (aux == 0)
                    Console.WriteLine("Nao foi encontrado um funcionario com esse cpf no sistema.");
            }
            return 0;
        }

       /* public int CalcularExtras(double cargaH)
        {
            int salario_extra = 0;


            if (cargaH <= 10) salario_extra += 75;
            if (cargaH > 10 && cargaH <= 15) salario_extra += 100;
            if (cargaH > 15 && cargaH <= 20) salario_extra += 150;
            if (cargaH > 20 && cargaH <= 25) salario_extra += 200;
            if (cargaH > 25) salario_extra += 250;
            return salario_extra;

        }*/

        public void BuscaFuncionario(string cpf)
        {
            int aux = 0;
            foreach (Funcionario func in Funcionarios)
            {
                if (cpf == func.Cpf)
                {
                    Console.WriteLine("Nome: " + func.Nome);
                    Console.WriteLine("Rg: " + func.Rg);
                    Console.WriteLine("Salario: " + func.Salario);
                    Console.WriteLine("Ganho Anual: " + calculaGanhoAnual(func.Cpf));
                    Console.WriteLine("Departamento: " + func.Dept);
                    if (func.Dept == "Producao")
                        Console.WriteLine("Turno: " + func.Turno);
                    Console.WriteLine("Cpf: " + func.Cpf);
                    Console.WriteLine("\n");
                    aux += 1;
                }
            }
            if (aux == 0)
                Console.WriteLine("Nao foi encontrado esse CPF no sistema");
            Console.WriteLine("\n");
        }
        public void GanhosAnuais()
        {
            bool isEmpty = !Funcionarios.Any();
            if (isEmpty)
            {
                Console.WriteLine("NAO TEM FUNCIONARIOS CADASTRADOS NO SISTEMA");
            }
            else
            {
                foreach (Funcionario func in Funcionarios)
                {
                    Console.WriteLine("Nome: " + func.Nome);
                    Console.WriteLine("Ganho Anual: " + calculaGanhoAnual(func.Cpf));
                    Console.WriteLine("\n");
                }
            }
        }

        public void ListaComExtras()
        {
            bool isEmpty = !Funcionarios.Any();
            if (isEmpty)
            {
                Console.WriteLine("NAO TEM FUNCIONARIOS CADASTRADOS NO SISTEMA");
            }
            else
            {
                foreach(Funcionario func in Funcionarios)
                {
                    if (func.Dept == "Vendas")
                    {
                        BuscaFuncionario(func.Cpf);
                    }
                }
            }
        }
        /*public void Extras()
        {
            
            foreach(Funcionario func in Funcionarios)
            {
                if (func.Dept == "Vendas")
                {
                    BuscaFuncionario(func.Cpf);
                }
            }
            }*/
        /* public void Extra(string cpf)
         {
             double aumento;
             if (f1[0] != null)
             {
                 for (int x = 0; x < i; x++)
                 {
                     if (f1[x].Cpf == cpf)
                     {
                         Console.WriteLine("Digite o valor da carga de horário do trabalhador");
                         aumento = Convert.ToDouble(Console.ReadLine());
                         f1[x].CalculaExtra(aumento);
                     }
                 }


             }
             else
             {
                 Console.WriteLine("Não existem funcionários cadastrados");
             }
         }*/
    }
}