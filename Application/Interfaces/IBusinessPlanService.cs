using Application.ServiceReponses;
using Application.ViewModels.BusinessPlanDTO;

namespace Application.Interfaces
{
    public interface IBusinessPlanService
    {
        Task<ServiceResponse<List<BusinessPlanViewDTO>>> GetAllBusinessPlans();
        Task<ServiceResponse<BusinessPlanViewDTO>> GetBusinessPlanById(int id);
        Task<ServiceResponse<BusinessPlanViewDTO>> CreateBusinessPlan(BusinessPlanCreateDTO businessPlanDto);
        Task<ServiceResponse<BusinessPlanViewDTO>> UpdateBusinessPlan(int id, BusinessPlanUpdateDTO businessPlanDto);
        Task<ServiceResponse<bool>> DeleteBusinessPlan(int id);
    }
}
